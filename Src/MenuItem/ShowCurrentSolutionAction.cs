using JetBrains.ActionManagement;
using JetBrains.IDE;
using JetBrains.ProjectModel;
using JetBrains.Util;

namespace JetBrains.ReSharper.PowerToys.MenuItem
{
  [ActionHandler]
  internal class AddMenuItem_ShowCurrentSolutionAction : IActionHandler
  {
    #region IActionHandler Members

    public void Execute(IDataContext context, DelegateExecute nextExecute)
    {
      // Fetch active solution from context.
      // It should be not null because it is checked in "Update". 
      // "Execute" is guaranteed to not be invoked if "Update" returns false.
      ISolution solution = context.GetData(DataConstants.SOLUTION);

      string message = string.Format("Currently active solution is {0}", solution.Name);
      MessageBox.ShowInfo(message, "AddMenuItem Sample Plugin");
    }

    public bool Update(IDataContext context, ActionPresentation presentation, DelegateUpdate nextUpdate)
    {
      // fetch active solution from context
      ISolution solution = context.GetData(DataConstants.SOLUTION);

      // enable this action if there is an active solution, disable otherwise
      return solution != null;
    }

    #endregion
  }
}