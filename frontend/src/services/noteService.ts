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

export const createNote = async(note:{Title:string,Content:string})=>{
  try{
    const response=await axios.post(API_URL,note);
    return response.data;
  }catch(error){
    console.error("Error posting notes",error);
    return null;
  }
}

export const getNoteById = async (noteId:number)=>{
  try{
    console.log("it called");
    const response=await axios.get(`${API_URL}/${noteId}`);
    return response.data;
  }catch(error){
    console.log("Error fetching note",error);
    return null;
  }
}

export const updateNote = async(noteId:number,note:{title:string,content:string})=>{
  try{
    const response = await axios.put(`${API_URL}/${noteId}`,note);
    return response.data;
  }catch(error){
    console.error("Error updating notes ",error);
    return null;
  }
}

export const deleteNote = async(noteId:number)=>{
  try{
    await axios.delete(`${API_URL}/${noteId}`);
    return true;
  }catch(error){
    console.log("Error deleting notes",error)
    return false;
  }
}