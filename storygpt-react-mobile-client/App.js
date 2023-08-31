import { StatusBar } from "expo-status-bar";
import { StyleSheet, Text, View } from "react-native";
import StorySwiper from "./components/StorySwiper";

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
          storyGPT
        </Text>
      </View>
      <View style={{ flex: 20 }}>
        <StorySwiper />
      </View>
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
    backgroundColor: "#fff",
  },
});
