import bcrypt from "bcrypt";
import { Schema, model } from "mongoose";

const schema = new Schema({
  username: {
    type: String,
    required: true,
    minlength: [2, "Username must be at least 2 characters long"],
  },
  email: {
    type: String,
    required: true,
    minlength: [10, "Email must be at least 10 characters long"],
    match: [/.+@.+\..+/, "Please enter a valid email address"],
  },
  password: {
    type: String,
    required: true,
    minlength: [4, "Password must be at least 4 characters long"],
  },
});

schema.pre("save", async function () {
  this.password = await bcrypt.hash(this.password, 10);
});

const User = model("User", schema);

export default User;
