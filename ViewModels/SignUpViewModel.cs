using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleApp.Features.SignUp;

namespace SampleApp.ViewModels;
public partial class SignUpViewModel : BaseViewModel
{
    public SignUpFormViewModel FormViewModel { get; }

    public SignUpViewModel(SignUpFormViewModel viewModel)
    {
        FormViewModel = viewModel;
    }
}
