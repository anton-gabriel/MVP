using Hotel.ViewModels;
using System;
using System.Collections.Generic;

namespace Hotel.VML
{
    internal sealed class ViewModelLocator
    {
        #region Private fields
        private readonly Dictionary<Type, object> viewModels = new Dictionary<Type, object>();
        #endregion

        #region Private methods
        private T CreateViewModel<T>() where T : class, new()
        {
            Type type = typeof(T);
            if (!this.viewModels.TryGetValue(type, out object existing))
            {
                existing = new T();
                this.viewModels[type] = existing;
            }
            return existing as T;
        }
        #endregion

        #region ViewModels
        public LoginViewModel LoginVM => CreateViewModel<LoginViewModel>();
        public RegisterViewModel RegisterVM => CreateViewModel<RegisterViewModel>();
        public MainViewModel MainVM => CreateViewModel<MainViewModel>();
        #endregion
    }
}
