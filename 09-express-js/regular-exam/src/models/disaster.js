import { Schema, model } from "mongoose";

const schema = new Schema({
  name: {
    type: String,
    required: true,
    minlength: [2, "Name must be at least 2 characters long"],
  },
  type: {
    type: String,
    required: true,
    enum: [
      "Wildfire",
      "Flood",
      "Earthquake",
      "Hurricane",
      "Drought",
      "Tsunami",
      "Other",
    ],
  },
  year: {
    type: Number,
    required: true,
    min: [0, "Year must be at least 0"],
    max: [2024, "Year cannot exceed 2024"],
  },
  location: {
    type: String,
    required: true,
    minlength: [3, "Location must be at least 3 characters long"],
  },
  image: {
    type: String,
    required: true,
    match: [/^https?:\/\//, "Image URL must start with http:// or https://"],
  },
  description: {
    type: String,
    required: true,
    minlength: [10, "Description must be at least 10 characters long"],
  },
  interestedList: [
    {
      type: Schema.Types.ObjectId,
      ref: "User",
    },
  ],
  owner: {
    type: Schema.Types.ObjectId,
    ref: "User",
    required: true,
  },
});

const Disaster = model("Disaster", schema);

export default Disaster;
