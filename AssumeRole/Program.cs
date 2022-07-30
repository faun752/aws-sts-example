using aws_sts_example;

var usecase = new S3UseCase();
var result = await usecase.FetchUsersAsync();
Console.WriteLine($"UserId is: {result.UserId}, UserName is: {result.UserName}");