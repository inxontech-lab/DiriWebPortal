using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Globalization;

namespace DiriWebPortal.Shared
{
    public partial class HeaderArea
    {
        //[Inject] IJSRuntime JS { get; set; } = default!;
        //[Inject] NavigationManager Navigation { get; set; } = default!;

        //private string _selectedLang = "en";
        //private string _selectedLangText = "English";
        //private string _selectedLangFlag = "en.webp";

        //private bool _jsInitialized = false;

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    if (firstRender && !_jsInitialized)
        //    {
        //        _jsInitialized = true;

        //        var lang = await JS.InvokeAsync<string>("localStorage.getItem", "preferredLanguage") ?? "en";
        //        _selectedLang = lang;
        //        _selectedLangText = lang == "bn" ? "বাংলা" : "English";
        //        _selectedLangFlag = lang == "bn" ? "bn.webp" : "en.webp";

        //        StateHasChanged(); // Refresh UI after getting language
        //    }
        //}

        //private async Task ChangeLanguage(string lang)
        //{
        //    _selectedLang = lang;
        //    _selectedLangText = lang == "bn" ? "বাংলা" : "English";
        //    _selectedLangFlag = lang == "bn" ? "bn.webp" : "en.webp";

        //    // Save selected language
        //    await JS.InvokeVoidAsync("localStorage.setItem", "preferredLanguage", lang);

        //    // Set culture cookie for Blazor
        //    await JS.InvokeVoidAsync("eval", $"document.cookie = '.AspNetCore.Culture=c={lang}|uic={lang};path=/'");

        //    // Reload the page to apply new culture
        //    Navigation.NavigateTo(Navigation.Uri, forceLoad: true);
        //}

        //protected override async Task OnInitializedAsync()
        //{
        //    var lang = await JS.InvokeAsync<string>("localStorage.getItem", "preferredLanguage") ?? "en";
        //    _selectedLang = lang;
        //    _selectedLangText = lang == "bn" ? "বাংলা" : "English";
        //    _selectedLangFlag = lang == "bn" ? "bn.webp" : "en.webp";
        //}
    }
}
