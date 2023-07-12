using Microsoft.AspNetCore.Components;
using RegistrationMedicineProject.Client.Pages;
using System.Net.Http.Json;

namespace RegistrationMedicineProject.Client.Services.RegistrationMedicineService;

public class RegistrationMedicineService : IRegistrationMedicineService
{
    private readonly HttpClient _http;
    private readonly NavigationManager _navigationManager;

    public RegistrationMedicineService(HttpClient http, NavigationManager navigationManager)
    {
        _http = http;
        _navigationManager = navigationManager;
    }
    public List<RegistrationMedicine> Medicines { get; set; } = new List<RegistrationMedicine>();
    public List<Retention> Retentions { get; set; } = new List<Retention>();

    public async Task CreateMedicine(RegistrationMedicine medicine)
    {
        var result = await _http.PostAsJsonAsync("api/registrationmedicine", medicine);
        await SetMedicines(result);
    }

    private async Task SetMedicines(HttpResponseMessage result)
    {
        var response = await result.Content.ReadFromJsonAsync<List<RegistrationMedicine>>();
        Medicines = response;
        _navigationManager.NavigateTo("registrationmedicines");
    }

    public async Task DeleteMedicine(int id)
    {
        var result = await _http.DeleteAsync($"api/registrationmedicine/{id}");
        await SetMedicines(result);
    }


    public  async Task GetRegistrationMedicines()
    {
        var result = await _http.GetFromJsonAsync<List<RegistrationMedicine>>("api/registrationmedicine");
        if (result != null)
        {
            Medicines = result;
        }

    }

    public async Task GetRetentions()
    {
        var result = await _http.GetFromJsonAsync<List<Retention>>("api/registrationmedicine/retentions");
        if (result != null)
            Retentions = result;
    }

    public async Task<RegistrationMedicine> GetSingleMedicine(int id)
    {
            var result = await _http.GetFromJsonAsync<RegistrationMedicine>($"api/registrationmedicine/{id}");
            if (result != null)
                return result;
            throw new Exception("Desculpe, medicamento não encontrado não encontrado. :/");
        
    }

    public async Task UpdateMedicine(RegistrationMedicine medicine)
    {
        var result = await _http.PutAsJsonAsync($"api/registrationmedicine/{medicine.Id}", medicine);
        await SetMedicines(result);
    }
}
