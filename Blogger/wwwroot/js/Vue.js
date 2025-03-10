const app = Vue.createApp({
    data() {
        return { mensagem: "Olá do Vue no Razor!", teste: "testando" };
    },
    methods: {
        alterarMensagem() {
            this.mensagem = "Mensagem alterada!";
        },
        alterarTeste() {
            this.teste = "teste alterado";
        }
    }
});
app.mount("#app");
