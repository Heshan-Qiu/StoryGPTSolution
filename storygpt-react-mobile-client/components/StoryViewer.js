// src/components/StoryViewer.js
import React, { useState, useEffect } from "react";
import { View, Button, Text, FlatList, StyleSheet } from "react-native";
import axios from "axios";

export default function StoryViewer() {
  const [stories, setStories] = useState([]);
  useEffect(() => {
    // Fetch stories from API
    axios
      .get("https://storygpt-api.azurewebsites.net/api/story/random")
      .then((response) => setStories(response.data))
      .catch((error) => console.error(error));
  }, []);

  return stories.map((story) => {
    return (
      <Text style={{ fontSize: 25 }} key={story.id}>
        {story.context}
      </Text>
    );
  });
}
