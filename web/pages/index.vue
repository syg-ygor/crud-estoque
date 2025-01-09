<template>
  <v-container>
    <v-card class="pa-4">
      <v-card-title class="headline text-cyan-darken-4">Ygor Marcelino da Silva</v-card-title>
      <v-card-subtitle>Desenvolvedor web/mobile</v-card-subtitle>
      <v-card-text>
        <div>Av. Cel. João Batista de São da Silveira e Souza</div>
        <div>Cachoeirinha, RS, 94920-100</div>
        <div>(51) 99005-6565</div>
        <div>ygormarcelinods@gmail.com</div>

        <v-divider class="my-4"></v-divider>

        <v-list>
          <v-list-item-groudiv>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title class="title text-cyan-darken-4">COMPETÊNCIAS</v-list-item-title>
                <div>
                  <ul>
                    <li>
                      <strong>Desenvolvimento Front-End:</strong> Criação de interfaces dinâmicas e responsivas
                      utilizando frameworks modernos como Vue.js, React, Angular e JQuery, integrados a bibliotecas de
                      design renomadas como Bootstrap, TailwindCSS e Styled Components, garantindo experiências de
                      usuário envolventes.
                    </li>
                    <li>
                      <strong>APIs e Back-End:</strong> Desenvolvimento de APIs robustas e escaláveis com Node.js
                      (NestJS, Express), Laravel, .NET e Spring Boot, assegurando alta performance e integração
                      eficiente com sistemas diversos.
                    </li>
                    <li>
                      <strong>Desenvolvimento Mobile:</strong> Construção de aplicativos móveis completos utilizando
                      React Native e Kotlin, com expertise em conexões Bluetooth, gerenciamento de permissões e
                      publicação de versões na Google Play Store.
                    </li>
                    <li>
                      <strong>Gerenciamento de Bancos de Dados:</strong> Experiência na manutenção e otimização de
                      bancos de dados relacionais e não relacionais, incluindo PostgreSQL, MySQL, Firebase e MongoDB,
                      com foco em alta disponibilidade e segurança.
                    </li>
                  </ul>
                </div>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-groudiv>
        </v-list>

        <v-divider class="my-4"></v-divider>

        <v-list>
          <v-list-item-groudiv>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title class="title text-cyan-darken-4">EXPERIÊNCIA</v-list-item-title>
                <div>
                  <ul>
                    <li>
                      <strong>ISat, Remoto - Desenvolvedor Web/Mobile Pleno</strong> (desde março de 2024)
                      <ul>
                        <li>Desenvolvimento e manutenção de aplicações Web utilizando React, JQuery e PHP.</li>
                        <li>Manutenção da API utilizando NodeJS e Sequelize, conectando a um banco PostgreSQL.</li>
                        <li>Desenvolvimento e manutenção de aplicações Mobile utilizando React Native e Kotlin.</li>
                      </ul>
                    </li>
                    <li>
                      <strong>Continental Tech, Remoto - Desenvolvedor Web/Mobile Pleno</strong> (dezembro de 2023 -
                      março de 2024)
                      <ul>
                        <li>Desenvolvimento e manutenção de aplicações Web utilizando JQuery.</li>
                        <li>Desenvolvimento e manutenção de APIs utilizando .Net com Dapper, conectando a um banco
                          SQLServer.</li>
                      </ul>
                    </li>
                    <li>
                      <strong>Sygecom Informática, Alvorada - Desenvolvedor Full-Stack JR</strong> (março de 2022 -
                      dezembro de 2023)
                      <ul>
                        <li>Desenvolvimento de aplicações Web utilizando VueJS.</li>
                        <li>Desenvolvimento de APIs utilizando Node.js (NestJS, Express), além de utilizar SocketIO para
                          processamento de dados em tempo real para um leilão online.</li>
                      </ul>
                    </li>
                  </ul>
                </div>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-groudiv>
        </v-list>

        <v-divider class="my-4"></v-divider>

        <v-list>
          <v-list-item-groudiv>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title class="title text-cyan-darken-4">FORMAÇÃO</v-list-item-title>
                <div>
                  <ul>
                    <li>
                      <strong>Descomplica Faculdade, Remoto - Bacharelado em Engenharia da Computação</strong> (desde
                      dezembro de 2022)
                    </li>
                    <li>
                      <strong>Instituto Federal de Educação Ciência e Tecnologia, Gravataí - Técnico em Informática para
                        a Internet</strong> (fevereiro de 2017 - dezembro de 2020)
                    </li>
                  </ul>
                </div>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-groudiv>
        </v-list>

        <v-divider class="my-4"></v-divider>

        <v-list>
          <v-list-item-groudiv>
            <v-list-item>
              <v-list-item-content>
                <v-list-item-title class="title text-cyan-darken-4">APRESENTAÇÃO</v-list-item-title>
                <div>
                  Sou um profissional dinâmico, criativo e comprometido, com habilidade para transformar desafios em
                  oportunidades. Tenho uma forte capacidade de organização e planejamento, sempre buscando soluções
                  práticas e inovadoras para alcançar os melhores resultados. Minha experiência me permitiu desenvolver
                  um trabalho colaborativo e eficiente em equipe, mantendo uma comunicação clara e respeitosa. Sou
                  proativo, curioso e determinado, características que me ajudam a aprender continuamente e a me adaptar
                  rapidamente a novas demandas e tecnologias. Além disso, valorizo a entrega de qualidade, priorizando a
                  satisfação do cliente e o sucesso do projeto como um todo. Minha motivação está em contribuir com
                  ideias e ações que realmente façam a diferença.
                </div>
              </v-list-item-content>
            </v-list-item>
          </v-list-item-groudiv>
        </v-list>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script>
export default {
  name: 'Curriculo',
}
</script>

<style scoped>
.headline {
  font-weight: bold;
  font-size: 24px;
}

.title {
  font-weight: bold;
}
</style>
