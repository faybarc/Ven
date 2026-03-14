
using Microsoft.AspNetCore.Components;
using Van.Shared.Entities;
using Ven.Frontend.Repositories;

namespace Ven.Frontend.Pages.Countries;

public partial class IndexCountries
{
    [Inject] private IRepository _repository { get; set; } = null!;
    public List<Country>? Countries { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var responseHttp = await _repository.GetAsync<List<Country>>("/api/countries");
        Countries = responseHttp.Response;
    }
}