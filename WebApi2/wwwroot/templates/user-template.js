const UserTemplate = `<v-app>
      <v-content>
        <v-container>
          <p>{{ id ? 'Пользователь' : 'Новый пользователь' }}</p>

            <v-form
              ref="form"
              v-model="valid"
              :lazy-validation="lazy"
            >
              <v-text-field
                v-model="item.surname"
                label="Фамилия"
                :rules="surnameRules"
                required
              ></v-text-field>

              <v-text-field
                v-model="item.firstName"
                label="Имя"
                :rules="firstNameRules"
                required
              ></v-text-field>

              <v-text-field
                v-model="item.patronymic"
                label="Отчество"
              ></v-text-field>

              <v-select
                v-model="item.gender"
                :items="genders"
                label="Пол"
              ></v-select>

              <v-text-field
                v-model="item.email"
                :rules="emailRules"
                label="E-mail"
                required
              ></v-text-field>

              <v-text-field
                v-model="item.hobby"
                label="Хобби"
              ></v-text-field>

              <v-text-field
                v-model="item.phone"
                label="Телефон"
              ></v-text-field>

              <v-text-field
                v-model="item.address"
                label="Адрес"
              ></v-text-field>

              <v-btn
                :disabled="!valid"
                color="success"
                class="mr-4"
                @click="save"
              >
                Сохранить
              </v-btn>

              <v-btn               
                class="mr-4"
                @click="cancel"
              >
                Отмена
              </v-btn>

            </v-form>

        </v-container>
      </v-content>
    </v-app>`;
export { UserTemplate };