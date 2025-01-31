import axios from "axios";

const API_URL = "http://localhost:7055/api/Notes"; // Update this if needed

export const getNotes = async () => {
  try {
    const response = await axios.get(API_URL);
    return response.data;
  } catch (error) {
    console.error("Error fetching notes:", error);
    return [];
  }
};
