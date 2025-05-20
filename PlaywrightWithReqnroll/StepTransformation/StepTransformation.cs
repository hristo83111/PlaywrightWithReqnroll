using PlaywrightWithReqnroll.Models;
using Reqnroll;

namespace PlaywrightWithReqnroll.StepTransformation;

[Binding]
public class StepTransformation
{
    [StepArgumentTransformation]
    public LoginCredentials LoginCredentialsTransformation(DataTable dataTable)
    {
        return dataTable.CreateInstance<LoginCredentials>();
    }
}
