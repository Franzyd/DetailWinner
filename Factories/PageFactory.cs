﻿using System;
using DetailWinner.Data;
using DetailWinner.ViewModels;

namespace DetailWinner.Factories;

public class PageFactory(Func<ApplicationPageNames, PageViewModel> factory)
{
    public PageViewModel GetPageViewModel(ApplicationPageNames pageName) => factory.Invoke(pageName);
}