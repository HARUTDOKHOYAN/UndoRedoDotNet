using UndoRedo.Commands;
using UndoRedo.Models;
using UndoRedo.Services;
using UndoRedo.Services.UndoRedoRecoverServices;
using UndoRedo.Snapshots;

internal class Program
{

    private static void Main(string[] args)
    {
        var model = new AClass();
        Console.WriteLine(model.Value);
        var udnoSnapshot = new AClassSnapshot() { Value = model.Value };
        model.Value = 34;
        var redoSnapshot = new AClassSnapshot() { Value = model.Value };
        Console.WriteLine(model.Value);

        var recoverService = new AClassRecoverService(model);
        var command = new UndoRedoCommand<AClassSnapshot>(udnoSnapshot , redoSnapshot , recoverService);

        UndoRedoService.Instants.Value.AddCommand(command);
        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine(model.Value);
        UndoRedoService.Instants.Value.Redo();
        Console.WriteLine(model.Value);
        
    }
}