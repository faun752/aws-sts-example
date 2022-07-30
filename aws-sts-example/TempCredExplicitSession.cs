using Amazon.Runtime.CredentialManagement;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;

namespace aws_sts_example
{
    internal class TempCredExplicitSession
    {
        public static async Task<Credentials> GetTemporaryCredentials()
        {
            try
            {
                var sharedFile = new SharedCredentialsFile();
                CredentialProfile basicProfile;

                sharedFile.TryGetProfile("sts-test", out basicProfile);

                // Issue temporary credential(Authority can be delegated with two accounts)
                AssumeRoleResponse assumeRoleResponse;

                using (var stsClient = new AmazonSecurityTokenServiceClient())
                {
                    var assumeRoleRequest = new AssumeRoleRequest
                    {
                        RoleArn = basicProfile.Options.RoleArn,
                        RoleSessionName = "testsession"
                    };

                    assumeRoleResponse = await stsClient.AssumeRoleAsync(assumeRoleRequest);
                }

                return assumeRoleResponse.Credentials;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new Credentials();
        }
    }
}
