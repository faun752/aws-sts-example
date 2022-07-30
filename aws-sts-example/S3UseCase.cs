using Amazon.S3;
using Amazon.S3.Model;
using aws_sts_example.Domain;
using System.Text.Json;

namespace aws_sts_example
{
    internal class S3UseCase
    {
        public async Task<UserInfo> FetchUsersAsync()
        {
            try
            {
                // Set authentication information in environment variables.(aws configure)
                var credentials = await TempCredExplicitSession.GetTemporaryCredentials();
                AmazonS3Client client = new AmazonS3Client(credentials, Amazon.RegionEndpoint.APNortheast1);

                GetObjectRequest request = new GetObjectRequest
                {
                    BucketName = "sts-test-2022",
                    Key = "user.json"
                };

                var response = await client.GetObjectAsync(request);

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                UserInfo userInfo = await JsonSerializer.DeserializeAsync<UserInfo>(response.ResponseStream);

                return userInfo ?? new UserInfo();
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (AmazonS3Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new UserInfo();
        }
    }
}
