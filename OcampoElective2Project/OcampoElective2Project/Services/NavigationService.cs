using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace OcampoElective2Project.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;

        public void NavigateTo(string pageKey, object parameter)
        {
            NavigateTo(pageKey, parameter, false);
        }

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public void GoBack()
        {
            _navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null, false);
        }

        public void NavigateTo(string pageKey, object parameter, bool replaceRoot)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor;
                    object[] parameters;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[]
                        {
                        };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                        {
                        parameter
                    };
                    }

                    if (constructor == null)
                    {
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);
                    }

                    var page = constructor.Invoke(parameters) as Page;

                    if (replaceRoot)
                    {
                        var root = _navigation.Navigation.NavigationStack[0];
                        _navigation.Navigation.InsertPageBefore(page, root);
                        _navigation.PopToRootAsync();
                    }
                    else
                    {
                        _navigation.PushAsync(page);
                    }
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public async Task ReplaceRoot(Page page)
        {
            var root = _navigation.Navigation.NavigationStack[0];
            _navigation.Navigation.InsertPageBefore(page, root);
            await PopToRootAsync(page);
        }

        private async Task PopToRootAsync(Page page)
        {
            while (_navigation.Navigation.ModalStack.Count > 0)
            {
                await _navigation.Navigation.PopModalAsync(false);
            }

            while (_navigation.CurrentPage != _navigation.Navigation.NavigationStack[0])
            {
                await _navigation.Navigation.PushAsync(page, false);
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }
    }
}
