import { createDrawerNavigator, createAppContainer, createStackNavigator, createSwitchNavigator } from "react-navigation";
import Login from "./pages/login";
import CadastroProjetos from "./pages/cadastroProjetos";
import CadastroUsuarios from "./pages/cadastroUsuarios";
import ListarProjetos from "./pages/listaProjetos";

const AuthStack = createStackNavigator({ Login });

const MainNavigator = createDrawerNavigator(
    {
        CadastroProjetos,
        CadastroUsuarios,
        ListarProjetos
    },
    {
        initialRouteName: "ListarProjetos",
        swipeEnabled: false,
        tabBarOptions: {
            showLabel: false,
            showIcon: false,
            inactiveBackgroundColor: "none",
            activeBackgroundColor: "none",
            activeTintColor: "none",
            inactiveTintColor: "none",
            style: {
                height: 50
            }
        }
    }
);

export default createAppContainer(
    createSwitchNavigator(
        {
            MainNavigator,
            AuthStack
        },
        {
            initialRouteName: "AuthStack"
        }
    )
);