## Summary
How to obtain temporary security credentials using AssumeRole

## Configuration details
`~/.aws/config`

```
[default]
region = ap-northeast-1
output = json
[profile sts-test]
region = ap-northeast-1
role_arn = arn:aws:iam::123456789123:role/xxx-role
output = json
```

## Credential Settings

`~/.aws/credentials`

```
[default]
aws_access_key_id = XXXXXXXXXXXXXXXXXXXX
aws_secret_access_key = XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
```