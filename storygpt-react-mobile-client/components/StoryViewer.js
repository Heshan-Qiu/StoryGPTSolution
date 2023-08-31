// src/components/StoryViewer.js
import React, { useState, useEffect } from "react";
import { Dimensions, View, Text, ScrollView } from "react-native";
import axios from "axios";

const { width, height } = Dimensions.get("window");

export default function StoryViewer() {
  const [stories, setStories] = useState([]);
  useEffect(() => {
    // Fetch stories from API
    axios
      .get("https://storygpt-api.azurewebsites.net/api/story/random3")
      .then((response) => setStories(response.data))
      .catch((error) => console.error(error));
  }, []);

  return (
    <ScrollView snapToInterval={width} decelerationRate="fast">
      {stories.map((story) => (
        <View style={{ flex: 20, padding: 10 }} key={story.id}>
          <Text style={{ fontSize: 25 }}>{story.context}</Text>
        </View>
      ))}
    </ScrollView>
  );
}
