import { createBottomTabNavigator, createAppContainer, createStackNavigator, createSwitchNavigator } from "react-navigation";
import Login from "./pages/login";
import CadastroProjetos from "./pages/cadastroProjetos";
import CadastroUsuarios from "./pages/cadastroUsuarios";
import ListarProjetos from "./pages/listaProjetos";

const AuthStack = createStackNavigator({ Login });

const MainNavigator = createBottomTabNavigator(
    {
        Login,
        CadastroProjetos,
        CadastroUsuarios,
        ListarProjetos
    },
    {
        initialRouteName: "Login",
        swipeEnabled: true,
        tabBarOptions: {
            showLabel: false,
            showIcon: true,
            inactiveBackgroundColor: "#dd99ff",
            activeBackgroundColor: "#B727FF",
            activeTintColor: "#FFFFFF",
            inactiveTintColor: "#FFFFFF",
            style: {
                height: 50
            }
        }
    }
);

// export default createAppContainer(MainNavigator);

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