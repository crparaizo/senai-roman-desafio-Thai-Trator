import React, { Component } from "react";

import {
  StyleSheet,
  View,
  Text,
  Image,
  ImageBackground,
  TextInput,
  TouchableOpacity,
  AsyncStorage,
  Button
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
    this.props.navigation.navigate("er");
  };

  render() {
    return (
      <ImageBackground
        // source={require("../assets/img/login.png")}
        style={StyleSheet.absoluteFillObject}
      >
        <Text style={styles.btnLoginText}>LOGIN</Text>
        <View style={styles.overlay} />
        <View style={styles.main}>
          <Image
            // source={require("../assets/img/loginIcon2x.png")}
            style={styles.mainImgLogin}
          />
          <TextInput
            style={styles.inputLogin}
            placeholder="email"
            placeholderTextColor="black"
            underlineColorAndroid="black"
            onChangeText={email => this.setState({ email })}
          />

          <TextInput
            style={styles.inputLogin}
            placeholder="senha"
            placeholderTextColor="#blue"
            password="true"
            underlineColorAndroid="blue"
            onChangeText={senha => this.setState({ senha })}
          />
          <TouchableOpacity
            style={styles.btnLogin}
            onPress={this._realizarLogin}
          >
            <Text style={styles.btnLoginText}>Logar - Botão</Text>
          </TouchableOpacity>
        </View>
      </ImageBackground>
    );
  }
}

const styles = StyleSheet.create({
  tabNavigatorIconProfile: { width: 25, height: 25, tintColor: "#FFFFFF" },
  // btnLogin: {
  //   height: 38,
  //   shadowColor: "rgba(0,0,0, 0.4)", // IOS
  //   shadowOffset: { height: 1, width: 1 }, // IOS
  //   shadowOpacity: 1, // IOS
  //   shadowRadius: 1, //IOS
  //   elevation: 3, // Android
  //   width: 240,
  //   borderRadius: 4,
  //   borderWidth: 1,
  //   borderColor: "#FFFFFF",
  //   backgroundColor: "#FFFFFF",
  //   justifyContent: "center",
  //   alignItems: "center",
  //   marginTop: 10
  // },
  // btnLoginText: {
  //   fontSize: 10,
  //   fontFamily: "OpenSans-Light",
  //   color: "#B727FF",
  //   letterSpacing: 4
  // }
});

export default Login;
