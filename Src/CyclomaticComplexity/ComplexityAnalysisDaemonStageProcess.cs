using System;
using JetBrains.Application.Progress;
using JetBrains.ReSharper.Daemon;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Tree;

namespace JetBrains.ReSharper.PowerToys.CyclomaticComplexity
{
  public class ComplexityAnalysisDaemonStageProcess : IDaemonStageProcess
  {
    private readonly IDaemonProcess myDaemonProcess;

    public ComplexityAnalysisDaemonStageProcess(IDaemonProcess daemonProcess)
    {
      myDaemonProcess = daemonProcess;
    }

    public void Execute(Action<DaemonStageResult> commiter)
    {
      // Getting PSI (AST) for the file being highlighted
      PsiManager manager = PsiManager.GetInstance(myDaemonProcess.Solution);
      IFile file = manager.GetPsiFile(myDaemonProcess.ProjectFile);
      if (file == null)
        return;

      // Running visitor against the PSI
      var elementProcessor = new ComplexityAnalysisElementProcessor(myDaemonProcess);
      file.ProcessDescendants(elementProcessor);

      // Checking if the daemon is interrupted by user activity
      if (myDaemonProcess.InterruptFlag)
        throw new ProcessCancelledException();

      // Commit the result into document
      commiter(new DaemonStageResult(elementProcessor.Highlightings));
    }
  }
}