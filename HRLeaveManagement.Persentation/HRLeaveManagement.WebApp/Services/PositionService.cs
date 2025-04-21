using HRLeaveManagement.Application.Features.LeaveRequest;
using System.Net.Http.Json;
using HRLeaveManagement.Application.Features.Position;
using HRLeaveManagement.Application.Features.Position.Commands.CreatePosition;
using HRLeaveManagement.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRLeaveManagement.Application.Response;
using System.Text.Json;
using HRLeaveManagement.WebApp.Model;
using System.Text;

namespace HRLeaveManagement.WebApp.Services
{
    public class PositionService : IPositionService
    {
        //private readonly HttpClient _http;
        //private readonly HttpClient _httpClient;
        private readonly HttpClient _http;

        public PositionService(HttpClient http)
        {
            // Constructor to initialize the HttpClient instance.
            // This instance is used to make HTTP requests to the API.
            // The HttpClient is injected via dependency injection.
            // The 'http' parameter is the injected HttpClient instance.
            // The '_http' field is assigned the injected HttpClient instance.
            // This allows the service to use the HttpClient for making API calls.
            // The HttpClient is typically configured in the Startup.cs or Program.cs file.
            // The injected HttpClient is used to make HTTP requests to the API.
            _http = http;
        }
        public async Task<List<PositionViewModel>> GetAllAsync()
        {
            // The GetAllAsync method is an asynchronous method that retrieves a list of PositionViewModel objects.
            // It uses the HttpClient instance (_http) to send a GET request to the API endpoint "/api/Position".

            return await _http.GetFromJsonAsync<List<PositionViewModel>>("/api/Position/GetPosition");
            // The above line is the correct way to call the API endpoint.
            // The GetFromJsonAsync method is used to send a GET request to the specified URL
            // and deserialize the JSON response into a List<PositionViewModel>.
            // The URL "/api/Position" is the endpoint for retrieving all positions.
            // The method returns a Task<List<PositionViewModel>>, which represents the asynchronous operation.
            // The result is a list of PositionViewModel objects.
        }


        public async Task<PositionViewModel> GetByIdAsync(int id)
        {
            // The GetByIdAsync method is an asynchronous method that retrieves a single PositionViewModel object by its ID.
            // It uses the HttpClient instance (_http) to send a GET request to the API endpoint "/api/Position/{id}".
            // return await _http.GetFromJsonAsync<PositionViewModel>($"/api/Position/{id}");
            try
            {
                var response = await _http.GetAsync($"/api/Position/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<PositionViewModel>();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }


        public async Task<BaseResponse<PositionViewModel>> CreateAsync(PositionViewModel positionViewModel)
        {
            // Correct way to use PostAsJsonAsync
            // var response = await _http.PostAsJsonAsync("/api/Position", positionViewModel);
            var response = await _http.PostAsJsonAsync<PositionViewModel>("/api/Position", positionViewModel);

            // The CreateAsync method is an asynchronous method that creates a new PositionViewModel object.

            // It uses the HttpClient instance (_http) to send a POST request to the API endpoint "/api/Position".
            var result = await response.Content.ReadAsStringAsync();
            // The response is read as a string and stored in the 'result' variable.
            var createPositionResponse = JsonSerializer.Deserialize<BaseResponse<PositionViewModel>>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            // The JSON response is deserialized into a BaseResponse<PositionViewModel> object.
            // The 'PropertyNameCaseInsensitive' option is set to true to ignore case when deserializing property names.
            // The method returns a Task<BaseResponse<PositionViewModel>>, which represents the asynchronous operation.
            // The result is a BaseResponse<PositionViewModel> object.
            // The result contains the created PositionViewModel object and any additional information.
            return createPositionResponse;
        }
        public async Task<bool> UpdateAsync(int id, PositionViewModel positionViewModel)
        {
            // The UpdateAsync method is an asynchronous method that updates a PositionViewModel object.
            // It uses the HttpClient instance (_http) to send a PUT request to the API endpoint "/api/Position".
            // The method is not implemented yet, so it throws a NotImplementedException.
            // The UpdateAsync method is an asynchronous method that updates a PositionViewModel object.
            // var emptyContent = new StringContent(JsonSerializer.Serialize(positionViewModel),
            //  Encoding.UTF8, "application/json");
            // The emptyContent variable is created to hold the serialized JSON content of the positionViewModel object.
            // The StringContent class is used to create HTTP content based on a string.
            // The JSON content is serialized using JsonSerializer.Serialize.
            // The content type is set to "application/json" to indicate that the content is in JSON format.


            //var response = await _http.PutAsync($"/api/Position/{id}", emptyContent);
            // The response variable holds the result of the PUT request.
            // The PUT request is sent to the API endpoint "/api/Position/{id}".    
            // The id parameter is used to specify the ID of the PositionViewModel object to be updated.
            // The method returns a Task<bool>, which represents the asynchronous operation.
            // The result is a boolean indicating whether the update was successful.    
            // The response.IsSuccessStatusCode property is checked to determine if the request was successful.
            // return response.IsSuccessStatusCode;
            try
            {
                var content = new StringContent(
                    JsonSerializer.Serialize(positionViewModel),
                    Encoding.UTF8,
                    "application/json");

                var response = await _http.PutAsync($"/api/Position/{id}", content);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                // Log the error if needed
                var error = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Update failed: {error}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Update exception: {ex}");
                return false;
            }

        }



        public async Task<bool> DeleteAsync(int id)
        {
            // The DeleteAsync method is an asynchronous method that deletes a PositionViewModel object.
            // It uses the HttpClient instance (_http) to send a DELETE request to the API endpoint "/api/Position/{id}".
            // The method is not implemented yet, so it throws a NotImplementedException.
            var response = await _http.DeleteAsync($"/api/Position/{id}");
            // The response variable holds the result of the DELETE request.
            // The DELETE request is sent to the API endpoint "/api/Position/{id}".
            // The id parameter is used to specify the ID of the PositionViewModel object to be deleted.
            // The method returns a Task<bool>, which represents the asynchronous operation.
            // The result is a boolean indicating whether the delete was successful.
            // The response.IsSuccessStatusCode property is checked to determine if the request was successful.
            return response.IsSuccessStatusCode;
        }

       
    }
}
