﻿using Hotel.ViewModels;
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
        public MainViewModel MainVM => CreateViewModel<MainViewModel>();
        public LoginViewModel LoginVM => CreateViewModel<LoginViewModel>();
        public RegisterViewModel RegisterVM => CreateViewModel<RegisterViewModel>();
        public UserViewModel UserVM => CreateViewModel<UserViewModel>();
        public ClientViewModel ClientVM => CreateViewModel<ClientViewModel>();
        public EmployeeViewModel EmployeeVM => CreateViewModel<EmployeeViewModel>();
        public AdminViewModel AdminVM => CreateViewModel<AdminViewModel>();
        public RoomViewModel RoomVM => CreateViewModel<RoomViewModel>();
        public OfferViewModel OfferVM => CreateViewModel<OfferViewModel>();
        public BookingsViewModel BookingsVM => CreateViewModel<BookingsViewModel>();
        public CheckoutViewModel CheckoutVM => CreateViewModel<CheckoutViewModel>();
        public UserCRUDViewModel UserCRUDVM => CreateViewModel<UserCRUDViewModel>();
        public ServiceCRUDViewModel ServiceCRUDVM => CreateViewModel<ServiceCRUDViewModel>();
        public OfferCRUDViewModel OfferCRUDVM => CreateViewModel<OfferCRUDViewModel>();
        public FeatureCRUDViewModel FeatureCRUDVM => CreateViewModel<FeatureCRUDViewModel>();
        public RoomCRUDViewModel RoomCRUDVM => CreateViewModel<RoomCRUDViewModel>();
        #endregion
    }
}
