using System.Text;
using AspNetCore.Authentication.ApiKey;
using Core.Interfaces;

namespace Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureAndAddAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(ApiKeyDefaults.AuthenticationScheme)
            .AddApiKeyInHeaderOrQueryParams(options =>
            {
                options.KeyName = "xApiKey";
                options.Realm = "Sample Web App";
                options.Events = new ApiKeyEvents
                {
                    // A delegate assigned to this property will be invoked just before validating the api key. 
                    // NOTE: Same as above delegate but slightly different implementation which will give same result.
                    OnValidateKey = async context =>
                    {
                        // custom code to handle the api key, create principal and call Success method on context.
                        var apiKeyRepository =
                            context.HttpContext.RequestServices.GetRequiredService<IApiKeyRepository>();
                        var apiKey = await apiKeyRepository.GetApiKeyAsync(context.ApiKey);
                        var isValid = apiKey != null &&
                                      apiKey.Key.Equals(context.ApiKey, StringComparison.OrdinalIgnoreCase);
                        if (isValid)
                        {
                            context.ValidationSucceeded(apiKey.OwnerName, apiKey.Claims); // claims are optional
                        }
                        else
                        {
                            // Set Fake StatusCode for exception message Filter
                            context.Response.StatusCode = 601;
                            context.ValidationFailed();
                        }
                    },

                    // A delegate assigned to this property will be invoked before a challenge is sent back to the caller when handling unauthorized response.
                    OnHandleChallenge = async context =>
                    {
                        // custom code to handle authentication challenge unauthorized response.
                        var customErrorMessage =
                            "An API request was received without the xApiKey header or as a parameter";
                        if (context.Response.StatusCode == 601)
                            customErrorMessage = "An API request was received with an invalid API key";

                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "text/plain";
                        var message = Encoding.UTF8.GetBytes(customErrorMessage);
                        await context.Response.Body.WriteAsync(message);
                        context.Handled(); // important! do not forget to call this method at the end.
                    },

                    // A delegate assigned to this property will be invoked if Authorization fails and results in a Forbidden response.
                    OnHandleForbidden = async context =>
                    {
                        // custom code to handle forbidden response.
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                        context.Response.ContentType = "application/text";
                        var message = Encoding.UTF8.GetBytes("Access to this resource is forbidden");
                        await context.Response.Body.WriteAsync(message);
                        context.Handled(); // important! do not forget to call this method at the end.
                    },

                    // A delegate assigned to this property will be invoked when the authentication succeeds. It will not be called if OnValidateKey delegate is assigned.
                    // It can be used for adding claims, headers, etc to the response.
                    OnAuthenticationSucceeded = context =>
                    {
                        //custom code to add extra bits to the success response.
                        context.Response.Headers.Add("SuccessCustomHeader", "From OnAuthenticationSucceeded");
                        return Task.CompletedTask;
                    },

                    // A delegate assigned to this property will be invoked when the authentication fails.
                    OnAuthenticationFailed = context =>
                    {
                        context.Fail("Failed to authenticate");
                        return Task.CompletedTask;
                    }
                };
            });
    }
}