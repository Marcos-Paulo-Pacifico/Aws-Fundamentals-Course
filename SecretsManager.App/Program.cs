using Amazon.SecretsManager;
using Amazon.SecretsManager.Model;

var secretsManagerClient = new AmazonSecretsManagerClient();

var listSecretVersionRequest = new ListSecretVersionIdsRequest()
{
    SecretId = "ApiKey",
    IncludeDeprecated = true
};

var versionResponse = await secretsManagerClient.ListSecretVersionIdsAsync(listSecretVersionRequest);

var request = new GetSecretValueRequest
{
    SecretId = "ApiKey"
};

var response = await secretsManagerClient.GetSecretValueAsync(request);
Console.WriteLine(response.SecretString);

var describeRequest = new DescribeSecretRequest()
{
    SecretId = "ApiKey"
};
var describeResponse = await secretsManagerClient.DescribeSecretAsync(describeRequest);

