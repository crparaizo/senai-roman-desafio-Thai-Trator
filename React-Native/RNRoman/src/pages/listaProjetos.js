import React, { Component } from "react";

import { Text, Image, StyleSheet, View, FlatList } from "react-native";

import api from "../services/api";

class ListarProjetos extends Component {
    // static navigationOptions = {
    //     tabBarIcon: ({ tintColor }) => (
    //         <Image
    //             source={require("../assets/img/logo.png")}
    //         />
    //     )
    // };

    constructor(props) {
        super(props);
        this.state = {
            listaProjetos: []
        };
    }

    componentDidMount() {
        // realizar a chamada a api
        // emulator -list-avds
        // emulator -avd nomeAVD
        this.carregarProjetos();
    }

    carregarProjetos = async () => {
        const resposta = await api.get("/projetos");
        const dadosDaApi = resposta.data;
        this.setState({ listaProjetos: dadosDaApi });
    };

    render() {
        return (
            // SafeAreaView
            <View >
                <View>
                    <View>
                        {/* <Image
                            source={require("../assets/img/logo.png")}
                        /> */}
                        <Text>{"Projetos".toUpperCase()}</Text>
                    </View>
                    <View />
                </View>

                <View >
                    <FlatList
                        data={this.state.listaProjetos}
                        keyExtractor={item => item.id}
                        renderItem={this.renderizaItem}
                    />
                </View>
            </View>
        );
    }

    renderizaItem = ({ item }) => (
        <View >
            <View>
                <Text >IdProjeto: {item.id}</Text>
                <Text >Titulo: {item.titulo}</Text>
                <Text > Tema: {item.idTema}</Text>
                <Text >Descrição: {item.descricao}</Text>
                <Text >IdUsuario: {item.idUsuario}</Text>
            </View>
        </View>
    );
}

export default ListarProjetos;