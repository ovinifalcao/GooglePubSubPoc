# Google PubSub Proof Of Concept

 Esse projeto se dedica a fazer prova de conceitos sobre:
-   Baixo nível de complexidade do biblioteca cliente do Google Pub Sub para C#.    
-   Testar o uso do Emulador Pubsub no Docker para possíveis usos em testes de integração.

## Como funciona?  
São dois projetos Console de .Net Core que usam a Lib do PubSub para C#. Ambos estão olhando para as configurações do emulador disponível no localhost:8085 pós composição do Docker. Cada um deles tem uma parte do que deve ser feito. Eles criam o tópico/inscrição e ficam prontos para Enviar/Receber mensagem de forma recursiva com o uso de um laço Do-While (feio, eu sei).

## Como Rodar?

Recupere e rode a dependencia do docker:

    docker compose up

Restaure os pacotes .Net:

    dotnet restore

Vá à pasta de cada projeto e então faça:

    dotnet run

Importante, dizer que é necessário subir rodar o docker compose antes de qualquer um dos projetos, pois eles vão tentar se conectar com essa instância do PubSub. Além disso, uma inscrição só pode ser criada depois que um tópico foi criado, logo, se tentar subir o projeto de Consumidor antes do Produtor isso vai resultar em erro, por conta disso existe um passo, uma espera intencional do código do Consumidor precedido de uma mensagem: “Podemos?” no console, para que você confirme (usando qualquer tecla) que o Produtor já foi configurado.


## Referências
[Como instalar a imagem Docker da Google Cloud CLI | Google Cloud CLI Documentation](https://cloud.google.com/sdk/docs/downloads-docker?hl=pt-br)

[Running GCP PubSub emulator on a local Docker environment | by Cristian Popescu | Medium](https://medium.com/@crip.popescu/running-gcp-pubsub-emulator-on-a-local-docker-environment-735c7f1e1f41)

[Como testar aplicativos localmente com o emulador | Pub/Sub Documentation | Google Cloud](https://cloud.google.com/pubsub/docs/emulator?hl=pt-br)