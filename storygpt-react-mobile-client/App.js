import { StatusBar } from "expo-status-bar";
import { StyleSheet, Text, View, PanResponder } from "react-native";
import { NavigationContainer } from "@react-navigation/native";
import StoryViewer from "./components/StoryViewer";

export default function App() {
  return (
    <View style={styles.container}>
      <View
        style={{
          flex: 1,
          backgroundColor: "#89cff0",
          alignItems: "center",
          justifyContent: "center",
        }}
      >
        <Text style={{ fontStyle: "italic", fontWeight: "bold" }}>
          StoryGPT
        </Text>
      </View>
      <NavigationContainer>
        <View style={{ flex: 20, padding: 10 }}>
          <StoryViewer />
        </View>
      </NavigationContainer>
      <View style={{ flex: 1, alignItems: "center" }}>
        <Text>Built by Heshan (George) Qiu</Text>
      </View>
      <StatusBar style="auto" />
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#f5f5f5",
  },
});
