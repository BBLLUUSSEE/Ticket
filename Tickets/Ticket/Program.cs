using Ticket;

bool quit = false;
do
{
    Console.WriteLine($"===========MENU==========\n");
    Console.WriteLine("[1] - Lista dei Ticket\n");
    Console.WriteLine("[2] - Lista dei Ticket (id)\n");
    Console.WriteLine("[3] - Lista dei Ticket (stato)\n");
    Console.WriteLine("[4] - Inserisci un nuovo Ticket\n");
    Console.WriteLine("[5] - Chiudere un Ticket\n");
    Console.WriteLine("[q] - QUIT\n");

    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            AdoNET.ShowAllTickets();
            break;
        case "2":
            AdoNET.ShowOnlyById();
            break;
        case "3":
            AdoNET.ShowOnlyByStato();
            break;
        case "4":
            AdoNET.InsertNewTicket();
            break;
        case "5":
            AdoNET.CloseTicket();
            break;
        case "q":
            quit = true;
            break;
        default:
            Console.WriteLine("Comando sconosciuto");
            break;

    }
} while (!quit);