# Pericia.Aspire.Minio

This project is just a quick test to create an Aspire integration for MinIO/S3

No Nuget package for now, but easy to integrate in your project : just copy and paste the files in the Pericia.Aspire.Minio in your project.

Look at the Pericia.Aspire.Minio.AppHost code to see how to integrate it, and in the Pericia.Aspire.Minio.SampleApp/Service folder to connect to S3 API.


A few things to work on :

- I made a connectionString expression for MinIO, but I'm not sure there's a standard for this, probably useless
- In the sample app, I use the Minio nuget package to connect to the S3 API. We should be able to make it work with the AWSSDK.S3 package as well, but it will need more configuration