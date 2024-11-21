using UndoRedo.Services.UndoRedoRecoverServices;
using UndoRedo.Snapshots;
using UndoRedo.Commands;
using UndoRedo.Services;
using UndoRedo.Models;

internal class Example
{

    private static AClassSnapshot udnoSnapshot ;
    private static AClassSnapshot redoSnapshot ;

    private static void Main(string[] args)
    {
        //create your model  
        var model = new AClass();

        ChangeAClassValue(model, 32);

        //create command for main incoker
        CreateUndoRedoCommand(model);

        //Execute main invoker undo/redo
        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        UndoRedoService.Instants.Value.Redo();
        Console.WriteLine($"Value after execution Redo command {model.Value}" );

        //activate sub invoker
        UndoRedoService.Instants.Value.ActivateSubInvokator();
        Console.WriteLine("\nActivate sub invokator \n" );

        ChangeAClassValue(model, 1453);
        //create command for sub incoker
        CreateUndoRedoCommand(model);
        Console.WriteLine("\n");
        ChangeAClassValue(model, 43);
        //create command for sub incoker
        CreateUndoRedoCommand(model);
        Console.WriteLine("\n");
        ChangeAClassValue(model, 488);
        //create command for sub incoker
        CreateUndoRedoCommand(model);
        Console.WriteLine("\n");

        


        //Execute sub invoker undo/redo
        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        Console.WriteLine($"Is Undo Stack Empty ` {UndoRedoService.Instants.Value.IsUndoStackEmpty}") ;

        UndoRedoService.Instants.Value.Redo();
        Console.WriteLine($"Value after execution Redo command {model.Value}" );


        //diactivate sub invoker
        UndoRedoService.Instants.Value.DiactivateSubInvoketor();
        Console.WriteLine("\nDiactivate sub invokator \n" );
        //Execute main invoker undo/redo
        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        UndoRedoService.Instants.Value.Undo();
        Console.WriteLine($"Value after execution Undo command {model.Value}" );

        UndoRedoService.Instants.Value.Redo();
        Console.WriteLine($"Value after execution Redo command {model.Value}" );

        UndoRedoService.Instants.Value.Redo();
        Console.WriteLine($"Value after execution Redo command {model.Value}" );
    }

    private static void CreateUndoRedoCommand(AClass model)
    {
        AClassRecoverService recoverService;
        UndoRedoCommand<AClassSnapshot> command;

        //create recover sercice for this model
        recoverService = new AClassRecoverService(model);
        
        // create command 
        command = new UndoRedoCommand<AClassSnapshot>(udnoSnapshot, redoSnapshot, recoverService);

        //add commad to stack
        UndoRedoService.Instants.Value.AddCommand(command);
    }

    private static void ChangeAClassValue(AClass model, int value)
    {
        //collect undo snapshot before value cheanging
        Console.WriteLine($"Value before changing {model.Value}");
        udnoSnapshot = new AClassSnapshot() { Value = model.Value };
        model.Value = value;

        //collect redo snapshot after value cheanging
        redoSnapshot = new AClassSnapshot() { Value = model.Value };
        Console.WriteLine($"Value after changing {model.Value}");
    }
} 