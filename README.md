# FindMyPub
This app allows you to browse pubs from the Leeds Beer Quest and find your favourite one. You can also insert your own pub or review of pubs.

Note: the app uses an in memory database seeded with data from the LBQ website, any new data is not persisted.

# Setup

## FindMyPubApi
The FindMyPubApi uses .net 6 and can be built and executed or run in docker.

### Docker

To run the api from docker, execute the build command from the api root folder (FindMyPubApi), include the -f parameter as the file lives in WebApi.

The api exposes both 80 an 433, in the below case we are mapping 80 to 2000, and you can access it on http://localhost:2000/swagger/index.html.
```
docker build -t find-my-pub-api . -f .\WebApi\Dockerfile
docker run -it  -p 2000:80 find-my-pub-api
```
