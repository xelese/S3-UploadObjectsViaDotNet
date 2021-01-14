// using Amazon;
// using Amazon.S3;
// using Amazon.S3.Model;
// using System;
// using System.Threading.Tasks;
//
// namespace Amazon.DocSamples.S3
// {
//     class ListObjectsTest
//     {
//         private const string bucketName = "*** bucket name ***";
//         // Specify your bucket region (an example region is shown).
//         private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USWest2;
//
//         private static IAmazonS3 client;
//
//         public static void Main2()
//         {
//             // 1. this is necessary for the endpoint
//             var config = new AmazonS3Config {ServiceURL = "https://s3.wasabisys.com"};
//             
//             // this will allow you to call whatever profile you have
//             var credentials = new StoredProfileAWSCredentials("wasabi");
//             
//             // create s3 connection with credential files and config.
//             _s3Client = new AmazonS3Client(credentials, config);
//             client = new AmazonS3Client(bucketRegion);
//             ListingObjectsAsync().Wait();
//         }
//
//         static async Task ListingObjectsAsync()
//         {
//             try
//             {
//                 ListObjectsV2Request request = new ListObjectsV2Request
//                 {
//                     BucketName = bucketName,
//                     MaxKeys = 10
//                 };
//                 ListObjectsV2Response response;
//                 do
//                 {
//                     response = await client.ListObjectsV2Async(request);
//
//                     // Process the response.
//                     foreach (S3Object entry in response.S3Objects)
//                     {
//                         Console.WriteLine("key = {0} size = {1}",
//                             entry.Key, entry.Size);
//                     }
//                     Console.WriteLine("Next Continuation Token: {0}", response.NextContinuationToken);
//                     request.ContinuationToken = response.NextContinuationToken;
//                 } while (response.IsTruncated);
//             }
//             catch (AmazonS3Exception amazonS3Exception)
//             {
//                 Console.WriteLine("S3 error occurred. Exception: " + amazonS3Exception.ToString());
//                 Console.ReadKey();
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Exception: " + e.ToString());
//                 Console.ReadKey();
//             }
//         }
//     }
// }