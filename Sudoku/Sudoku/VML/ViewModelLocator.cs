﻿using Sudoku.ViewModels;
using System;
using System.Collections.Generic;

namespace Sudoku.VML
{
    class ViewModelLocator
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
        public GameViewModel GameVM => CreateViewModel<GameViewModel>();
        public UserViewModel UserVM => CreateViewModel<UserViewModel>();
        public CreateUserViewModel CreateUserVM => CreateViewModel<CreateUserViewModel>();
        public UserStatisticsViewModel UserStatisticsVM => CreateViewModel<UserStatisticsViewModel>();
        #endregion
    }
}
