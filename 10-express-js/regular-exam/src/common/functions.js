import jwtGenerator from "jsonwebtoken";
import { jwt as jwtConstants } from "../common/constants.js";

export function generateToken(payload, expiresIn = "7d") {
  return jwtGenerator.sign(payload, jwtConstants.secret, {
    expiresIn,
  });
}

export function getErrorMessage(error) {
  switch (error.name) {
    case "ValidationError":
      return Object.values(error.errors).at(0).message;
    default:
      return error.message;
  }
}
