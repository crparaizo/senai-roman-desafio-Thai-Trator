import React, { Component } from "react";

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

import api from "../services/api";

class Login extends Component {
  static navigationOptions = {
    header: null
  };

  constructor(props) {
    super(props);
    this.state = { email: "", senha: "" };
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
        <Text >LOGIN</Text>
        <View />
        <View >
          <Image
            // source={require("../assets/img/loginIcon2x.png")}
          />
          <TextInput
            placeholder="email"
            placeholderTextColor="black"
            underlineColorAndroid="black"
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            placeholder="senha"
            placeholderTextColor="#blue"
            password="true"
            underlineColorAndroid="blue"
            onChangeText={senha => this.setState({ senha })}
          />
          <TouchableOpacity
            onPress={this._realizarLogin}
          >
            <Text >Logar</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

export default Login;
