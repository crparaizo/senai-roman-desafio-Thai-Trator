import Login from "./pages/login";
import CadastroProjetos from "./pages/cadastroProjetos";
import CadastroUsuarios from "./pages/cadastroUsuarios";
import ListarProjetos from "./pages/listaProjetos";
import { createDrawerNavigator, createAppContainer } from "react-navigation";

const MainNavigator = createDrawerNavigator(
    {
        Login,
        CadastroProjetos,
        CadastroUsuarios,
        ListarProjetos
    },
    {
        initialRouteName: "Login",
        tabBarOptions: {
            showLabel: false,
            showIcon: true,
            inactiveBackgroundColor: "#dd99ff",
            activeBackgroundColor: "#B727FF",
            style: {
                height: 50
            }
        }
    }
);

export default createAppContainer(MainNavigator);