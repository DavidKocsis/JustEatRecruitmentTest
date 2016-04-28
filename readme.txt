1.How long did you spend on the coding test? What would you add to your solution if you had more time? If you didn't spend much time on the coding test then use this as an opportunity to explain what you would add.
 I have spent about 3 hours on the technical test. If I had more time I woulld add better exception handling as at the moment there is only an exception for entering the wrong postcode. I would also make the apiclient more flexible as at the moment it doesn't take more than a single variable

2.What was the most useful feature that was added to the latest version of your chosen language? Please include a snippet of code that shows how you've used it.
I am currently still working with dotnet 4.0 so I haven't had a chance to use some of the new features of dotnet. In my spare time I have been reading up on dotnet integrating with Xamarin as well as learning about dot net core.



3 How would you track down a performance issue in production? Have you ever had to do this?
check if any other teams are affected or investigating
Check alerting and performance counters 
check all server instances to see if the performance issue is occuring on all of them
Check differences on server location image version. Are they A/B testing.
Check if there is any load testing in progress
Try and recreate defect in production using test data
Check logs filter requests by affected servers.
Take affected servers out of the live pool.
Run some profiling tools on the affected servers.




How would you improve the JUST EAT APIs that you just used?
The api is returning a lot of data most of which looks like it would be used once more details are requested for the restaurant. Maybe have a get call to only get the basic details for each restaurant

Please describe yourself using JSON.

{
	"DavidKocsis": {
		"About": {
			"BirthDate": "25/02/1985",
			"nationality": "Hungarian",
			"Interests": [{
				"interest": "cinema"
			}, {
				"interest": "running"
			}, {
				"interest": "travelling"
			}]
		}
	}
}