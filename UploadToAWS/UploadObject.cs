// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved. 
// SPDX-License-Identifier:  Apache - 2.0

using System;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;

namespace UploadToAWS
{
    internal static class UploadObject
    {
        private static IAmazonS3 _s3Client;

        private const string BucketName = "";

        private const string ObjectName1 = "";

        // updated it to take any object from desktop, just adjust the file name above
        private static readonly string PathToDesktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        private static async Task Main()
        {
            // 1. this is necessary for the endpoint
            var config = new AmazonS3Config {ServiceURL = "https://s3.wasabisys.com"};

            // this will allow you to call whatever profile you have
            // var credentials = new StoredProfileAWSCredentials("sahanip");

            // create s3 connection with credential files and config.
            // _s3Client = new AmazonS3Client(credentials, config);

            // input access key id and secret access key.
            const string accessKeyId = "";
            const string secretAccessKey = "";
            
            // create s3 connection with credential files and config.
            _s3Client = new AmazonS3Client(accessKeyId, secretAccessKey, config);

            // The method expects the full path, including the file name.
            var path = $"{PathToDesktop}/{ObjectName1}";

            await UploadObjectFromFileAsync(_s3Client, BucketName, ObjectName1, path);
        }

        /*/// <summary>
        /// This method uploads a file to an Amazon S3 bucket. This
        /// example method also adds metadata for the uploaded file.
        /// </summary>
        /// <param name="client">An initialized Amazon S3 client object.</param>
        /// <param name="bucketName">The name of the S3 bucket to upload the
        /// file to.</param>
        /// <param name="objectName">The destination file name.</param>
        /// <param name="filePath">The full path, including file name, to the
        /// file to upload. This doesn't necessarily have to be the same as the
        /// name of the destination file.</param>*/
        private static async Task UploadObjectFromFileAsync(
            IAmazonS3 client,
            string bucketName,
            string objectName,
            string filePath)
        {
            try
            {
                var putRequest = new PutObjectRequest
                {
                    BucketName = bucketName,
                    Key = objectName,
                    FilePath = filePath
                };
                putRequest.Metadata.Add("x-amz-meta-title", "someTitle");
                await client.PutObjectAsync(putRequest);
            }
            catch (AmazonS3Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}