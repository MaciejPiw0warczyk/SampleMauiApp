using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Features.LogIn;

namespace SampleApp.ViewModels;
public partial class LoginPageViewModel : BaseViewModel
{
    public LogInFormViewModel FormViewModel { get; }
    public LoginPageViewModel(LogInFormViewModel formModel)
    {
        FormViewModel = formModel;
    }
}
