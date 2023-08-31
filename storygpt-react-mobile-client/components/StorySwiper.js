import React, { useState, useEffect } from "react";
import {
  Dimensions,
  StyleSheet,
  View,
  ScrollView,
  Image,
  Text,
} from "react-native";
import axios from "axios";

const { width, height } = Dimensions.get("window");

export const assets = [
  require("../assets/1.jpg"),
  require("../assets/2.jpg"),
  require("../assets/3.jpg"),
  require("../assets/4.jpg"),
  require("../assets/5.jpg"),
];

const StorySwiper = () => {
  const [stories, setStories] = useState([]);
  const [fetchNumber, setFetchNumber] = useState(0);
  const [scrollExecuted, setScrollExecuted] = useState(false);

  useEffect(() => {
    // Fetch stories from API
    axios
      .get("https://storygpt-api.azurewebsites.net/api/story/random3")
      .then((response) => setStories(response.data))
      .catch((error) => console.error(error));
  }, []);

  useEffect(() => {
    fetchStories();
  }, [fetchNumber]);

  const fetchStories = async () => {
    console.log("fetchStories");
    axios
      .get("https://storygpt-api.azurewebsites.net/api/story/random", {
        params: { ids: stories.map((story) => story.id) },
      })
      .then((response) => {
        const newStory = response.data[0];
        if (stories.some((story) => story.id === newStory.id)) {
          console.log("duplicate story, id: " + newStory.id);
        } else {
          console.log("new story, id: " + newStory.id);
          setStories((prevStories) => [...prevStories, newStory]);
        }
      })
      .catch((error) => console.error(error));
  };

  const handleScroll = (event) => {
    if (!scrollExecuted) {
      // Execute your scroll handling logic here
      console.log("Scroll event executed");

      // Set the flag to prevent further execution in this scroll event
      setScrollExecuted(true);

      setFetchNumber((prevNumber) => prevNumber + 1);
    }
  };

  const resetScrollFlag = () => {
    // Reset the flag when scroll event ends or starts anew
    setScrollExecuted(false);
  };

  return (
    <View style={styles.container}>
      <ScrollView
        snapToInterval={height}
        decelerationRate="fast"
        onScroll={handleScroll}
        onScrollBeginDrag={resetScrollFlag}
      >
        {stories.map((story) => (
          <View key={story.id} style={styles.picture}>
            <Image
              source={assets[Math.floor(Math.random() * assets.length)]}
              style={styles.image}
            />
            <Text style={styles.text}>{story.context}</Text>
          </View>
        ))}
      </ScrollView>
    </View>
  );
};

export default StorySwiper;

const styles = StyleSheet.create({
  container: {
    backgroundColor: "black",
  },
  picture: {
    width,
    height,
    overflow: "hidden",
  },
  image: {
    width: width,
    height: height - 100,
  },
  text: {
    position: "absolute",
    // top: 10, // Adjust the top position to place the text as desired
    fontSize: 25,
    fontWeight: "bold",
    color: "white",
    backgroundColor: "rgba(0, 0, 0, 0.7)", // Semi-transparent background for better text visibility
    padding: 10,
  },
});
