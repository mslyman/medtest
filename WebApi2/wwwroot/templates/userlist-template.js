const UserlistTemplate = `<v-app>
      <v-content>
        <v-container>
          <p>Пользователи</p>

          <v-data-table
            :headers="headers"
            :items="items"
            :items-per-page="5"
            class="elevation-1"
          >
            <template v-slot:item.action="{ item }">

            <v-icon
                small
                class="mr-2"
                @click="editItem(item)">fas fa-pencil-alt</v-icon>



            <v-icon
                small
                @click="deleteItem(item)">fas fa-trash-alt</v-icon>
            </template>
          </v-data-table>

        </v-container>
      </v-content>
    </v-app>`;
export { UserlistTemplate };