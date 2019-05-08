import React, { Component } from "react";

import { Text, Image, StyleSheet } from "react-native";

class Login extends Component {
  static navigationOptions = {
    tabBarIcon: ({ tintColor }) => (
      <Image
        source={require("../assets/img/logo.png")}
        style={styles.tabNavigatorIconProfile}
      />
    )
  };

  render() {
    return <Text style={{ fontSize: 40 }}>Login</Text>;
  }
}

const styles = StyleSheet.create({
  tabNavigatorIconProfile: { width: 25, height: 25, tintColor: "#FFFFFF" }
});

export default Login;
