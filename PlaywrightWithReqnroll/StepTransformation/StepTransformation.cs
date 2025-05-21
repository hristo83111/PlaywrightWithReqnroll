using PlaywrightWithReqnroll.Models;
using Reqnroll;

namespace PlaywrightWithReqnroll.StepTransformation;

[Binding]
public class StepTransformation
{
    [StepArgumentTransformation]
    public LoginCredentials LoginCredentialsTransformation(DataTable dataTable)
        => dataTable.CreateInstance<LoginCredentials>();
}
