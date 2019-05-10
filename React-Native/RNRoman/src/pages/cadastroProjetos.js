import React, { Component } from "react";
import axios from "axios";

import {
    StyleSheet,
    View,
    Text,
    Image,
    ImageBackground,
    TextInput,
    TouchableOpacity,
    AsyncStorage
} from "react-native";

class CadastroProjetos extends Component {
    static navigationOptions = {
        header: null
    };

    constructor(props) {
        super(props);
        this.state = { titulo: "", idTema: "", descricao: "", idUsuario: "" };
    }

    cadastrarProjeto = async () => {

        let teste = {
            titulo: this.state.titulo,
            idTema: this.state.idTema,
            descricao: this.state.descricao,
            idUsuario: this.state.idUsuario
        }

        await axios.post("http://192.168.3.151:5000/api/projetos", teste, {
            headers: {
                "Content-Type": "application/json"
            }
        })
            .then(response => {
                console.warn('Foi', response)
            })
            .catch(error => console.warn(error))
        this.props.navigation.navigate('ListarProjetos')
    }

    render() {
        return (
            <ImageBackground
                // source={require("../assets/img/login.png")}
                style={StyleSheet.absoluteFillObject}
            >
                <Text >CADASTRO</Text>
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
                        onPress={this.cadastrarProjeto}
                    >
                        <Text >Cadastrar</Text>
                    </TouchableOpacity>
                </View>
            </ImageBackground>
        );
    }
}

export default CadastroProjetos;