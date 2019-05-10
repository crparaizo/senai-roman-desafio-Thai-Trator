import React, { Component } from "react";

import { Text, Image, StyleSheet } from "react-native";

class CadastroProjetos extends Component {
    static navigationOptions = {
        header: null
    };

    constructor(props) {
        super(props);
        this.state = { titulo: "", idTema: "", descricao: "", idUsuario: "" };
    }

    _realizarLogin = async () => {
        // console.warn(this.state.email + this.state.senha);

        const resposta = await api.post("/login", {
            email: this.state.email,
            senha: this.state.senha
        });

        const token = resposta.data.token;
        await AsyncStorage.setItem("userToken", token);
        this.props.navigation.navigate("MainNavigator");

    };

    render() {
        return (
            <ImageBackground
                // source={require("../assets/img/login.png")}
                style={StyleSheet.absoluteFillObject}
            >
                <Text >CADASTRO</Text>
                <View />
                <View >
                    <Image
                    // source={require("../assets/img/loginIcon2x.png")}
                    />
                    <TextInput
                        placeholder="titulo"
                        placeholderTextColor="black"
                        underlineColorAndroid="black"
                        onChangeText={titulo => this.setState({ titulo })}
                    />
                    <TextInput
                        placeholder="idTema"
                        placeholderTextColor="blue"
                        underlineColorAndroid="blue"
                        onChangeText={idTema => this.setState({ idTema })}
                    />
                    <TextInput
                        placeholder="descricao"
                        placeholderTextColor="green"
                        underlineColorAndroid="green"
                        onChangeText={descricao => this.setState({ descricao })}
                    />
                    <TextInput
                        placeholder="idUsuario"
                        placeholderTextColor="purple"
                        underlineColorAndroid="purple"
                        onChangeText={idUsuario => this.setState({ idUsuario })}
                    />
                    <TouchableOpacity
                        onPress={this._realizarLogin}
                    >
                        <Text >Cadastrar</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>
        );
    }
}

export default CadastroProjetos;