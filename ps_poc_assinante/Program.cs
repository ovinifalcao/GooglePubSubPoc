using ps_poc_assinante;

Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8085");
Console.WriteLine("===== CONSUMER ======");
Console.WriteLine("Podemos?...");
Console.ReadKey();
Console.WriteLine("Configurando a Inscrição");

var structure = new StructureCreator();
var projectId = "some-project-id";
var subs = await structure.CreateSubscription(projectId, "GuestsQueue", "PrepareRoom");
var produce = new Consumer();
Console.WriteLine("Subs criado com sucesso!");
Console.WriteLine("Posso ler?, press enter");
Console.ReadKey();
var resposta = "";

do
{
    await produce.ReciveMessage(subs);
    Console.WriteLine("Parar? Y ou N:");
    resposta = Console.ReadLine();
}
while (!resposta!.Contains('N'));
