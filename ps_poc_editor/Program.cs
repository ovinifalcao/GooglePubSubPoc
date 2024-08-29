using ps_poc_editor;


Environment.SetEnvironmentVariable("PUBSUB_EMULATOR_HOST", "localhost:8085");
Console.WriteLine("===== PRODUCER ======");
Console.WriteLine("Configurando Tópico");

var structure = new StructureCreator();
var projectId = "some-project-id";
var topic = await structure.CreateTopic(projectId, "GuestsQueue");
var produce = new Producer();
Console.WriteLine("Tópico criado com sucesso!");
var resposta = "";

do
{
    Console.WriteLine("Escreva a mensagem que deve ser enviado");
    var mensagem = Console.ReadLine();
    await produce.SendMessage(projectId, topic, mensagem!);
    Console.WriteLine("a mensagem foi inscrita no topico");
    Console.Write("quer enviar mais uma? Y OU N?");
    resposta = Console.ReadLine();
}
while (!resposta!.Contains('N'));
